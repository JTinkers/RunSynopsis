<template>
    <div v-if='show' id='results'>
        <TransitionGroup name='fade'
            mode='out-in' 
            appear
        >
            <div v-if='articles.length' class='list'>
                <span class='list-title' v-text='articlesLabel'/>
                <div class='list-items'>
                    <TransitionGroup name='fade'
                        mode='out-in' 
                        appear
                    >
                        <router-link v-for='article in articles'
                            class='item'
                            :key='article.id'
                            :to='getArticlePath(article)'
                            v-text='article.title'
                        />
                    </TransitionGroup>
                </div>
            </div>
            <div v-if='posts.length' class='list'>
                <span class='list-title' v-text='postsLabel'/>
                <div class='list-items'>
                    <TransitionGroup name='fade'
                        mode='out-in' 
                        appear
                    >
                        <router-link v-for='post in posts'
                            class='item'
                            :key='post.id'
                            :to='getPostPath(post)'
                            v-text='post.title'
                        />
                    </TransitionGroup>
                </div>
            </div>
        </TransitionGroup>
    </div>
</template>

<script lang='ts' setup>
    import { ref, watch, computed } from 'vue'
    import { useService } from '@/core'
    import { searchQuery } from './gql/searchQuery'
    import { IArticle, IPost, IApiService } from '@/core/domain/api'

    const emit = defineEmits(['found'])

    const props = defineProps(
    {
        query:
        {
            type: String,
            required: true
        }
    })

    const api = useService<IApiService>('IApiService')
    const articles = ref<Array<IArticle>>([])
    const posts = ref<Array<IPost>>([])
    const show = computed(() => articles.value.length || posts.value.length)
    const articlesLabel = computed(() => `Articles (${articles.value.length})`)
    const postsLabel = computed(() => `Posts (${posts.value.length})`)

    await search(props.query)

    async function search(query: string)
    {
        const result = await api.query(searchQuery, 
        {
            query
        })

        articles.value = result.articles
        posts.value = result.posts

        emit('found', articles.value.length + posts.value.length)
    }

    function getArticlePath(item: IArticle)
    {
        return (
        { 
            name: 'articles-view', 
            params:
            {
                id: item.id,
                slug: item.slug
            }
        })
    }

    function getPostPath(item: IPost)
    {
        return (
        { 
            name: 'posts-view', 
            params:
            {
                id: item.id,
                slug: item.slug
            }
        })
    }

    watch(() => props.query, async (n, o) =>
    {
        if (n == o)
            return 
            
        await search(n)
    })
</script>

<style lang='scss' scoped>
    #results 
    {
        display: grid;
        grid-auto-rows: 1fr;
        grid-row-gap: 16px;
        max-height: 50vh;
        overflow: hidden;
    }

    .list
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
        overflow: hidden;
    }

    .list-title
    {
        font-family: $font-family-secondary;
        font-size: 12px;
        font-weight: 500;
    }

    .list-items
    {
        display: flex;
        flex-direction: column;
        border: 1px solid scale-color($background, $lightness: -5%);
        grid-row-gap: 8px;
        overflow: auto;
        padding: 8px;
    }

    .item
    {
        display: flex;
        background: scale-color($background, $lightness: -5%);
        font-family: $font-family-secondary;
        font-size: 12px;
        font-weight: 500;
        line-height: 1.25;
        padding: 8px;
        border-radius: 3px;
        transition: all 0.2s ease;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }
</style>