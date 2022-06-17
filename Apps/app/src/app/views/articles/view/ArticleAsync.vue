<template>
    <div id='article'>
        <div id='dates'>
            <span id='written-at' v-text='writtenAt'/>
            <span id='updated-at' v-text='updatedAt'/>
        </div>
        <Header :article='article!'/>
        <Markdown id='content'
            :source='content'
            :highlight='highlight'
            typographer
            linkify
        />
    </div>
</template>

<script lang='ts' setup>
    import Header from './Header.vue'
    import { ref, reactive, computed } from 'vue'
    import { useRoute } from '@/core/domain/router'
    import { useService } from '@/core'
    import { IArticle, Article, IApiService } from '@/core/domain/api'
    import { getArticleQuery } from './gql/getArticleQuery'
    import { formatDistance } from 'date-fns'
    import 'highlight.js/scss/github-dark-dimmed.scss'

    const api = useService<IApiService>('IApiService')
    const route = useRoute()

    const article = ref<IArticle>()
    article.value = await fetch()

    const 
    { 
        content, 
    } = reactive(article.value!)

    const writtenAt = computed(() =>
    {
        const phrase = formatDistance(new Date(article.value!.writtenAt), new Date(), 
        { 
            addSuffix: true
        })

        return 'Written ' + phrase
    })

    const updatedAt = computed(() =>
    {
        const phrase = formatDistance(new Date(article.value!.writtenAt), new Date(), 
        { 
            addSuffix: true
        })

        return 'Updated ' + phrase
    })

    const highlight = (
    {
        hljs: require('highlight.js')
    })

    async function fetch(): Promise<Article>
    {
        const data = (await api.query(getArticleQuery, 
        { 
            id: route.params.id 
        }))                
        .article

        return new Article(data)
    }
</script>

<style lang='scss' scoped>
    #article
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 32px;
        padding: 32px;
        overflow: auto;
    }

    #dates
    {
        display: flex;
        color: scale-color($background, $lightness: -40%);
        font-size: 14px;
        font-family: $font-family-primary;
    }

    #updated-at
    {
        margin-left: auto;
    }

    :deep(#content)
    {
        display: flex;
        flex-direction: column;

        *
        {
            &:first-child
            {
                margin-top: 0;
            }

            &:last-child
            {
                margin-bottom: 0;
            }
        }

        h1, h2, h3, h4, h5, h6
        {
            margin: 0;
            margin-bottom: 12px;
            margin-top: 36px;
        }

        p
        {
            margin-bottom: 12px;
            font-family: $font-family-primary;
        }

        pre
        {
            margin: 0;
            margin-bottom: 12px;
            overflow-x: auto;
            max-height: 400px;
            padding-right: 2px;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
        }

        ul, ol
        {
            display: flex;
            flex-direction: column;
            list-style-position: inside;
            grid-row-gap: 12px;
            padding: 0;
            margin: 0;
            margin-bottom: 16px;
        }

        a
        {
            color: scale-color($orange, $lightness: -20%);
            transition: all 0.2s ease-in-out;

            &:hover
            {
                color: $orange;
            }
        }
    }
</style>