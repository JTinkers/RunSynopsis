<template>
    <div ref='list' 
        id='list' 
        @scroll='(e) => onScroll(e.target as HTMLDivElement)'
    >
        <div id='items'>
            <TransitionGroup name='fade'
                mode='out-in' 
                appear
            >
                <Article v-for='article in articles'
                    class='article'  
                    :key='article.id' 
                    :article='article'
                />
            </TransitionGroup>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import Article from './Article.vue'
    import { ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IArticle, IApiService, IPageInfo } from '@/core/domain/api'
    import { getArticlesQuery } from './gql/getArticlesQuery'

    const api = useService<IApiService>('IApiService')
    const limit = 20
    const articles = ref<Array<IArticle>>([])
    const pageInfo = ref<IPageInfo | null>(null)
    const isLoading = ref(false)
    const list = ref<HTMLDivElement | null>(null)
    
    await fetch(limit)

    async function fetch(
        first: number | null = null,
        last: number | null = null,
        after: string | null = null, 
        before: string | null = null,
    )
    {
        isLoading.value = true

        const response = (await api.query(getArticlesQuery, 
        { 
            first: first,
            last: last,
            after: after,
            before: before,
        }))
        .response

        isLoading.value = false

        articles.value.push(...response.articles)

        pageInfo.value = response.pageInfo
    }

    async function onScroll(element: HTMLDivElement | null)
    {
        if (element === null)
            return

        const { scrollTop: top, clientHeight: ch, scrollHeight: sh } = element

        let traveled = top / (sh - ch)

        if (sh == ch)
            traveled = 1

        if (isLoading.value)
            return

        if (!pageInfo.value?.hasNextPage)
            return

        if (traveled == 1)
            await fetch(limit, null, pageInfo.value?.endCursor, null)
    }

    onMounted(async () => await onScroll(list.value))
</script>

<style lang='scss' scoped>
    #list
    {
        overflow: auto;
        width: 100%;
        padding: 32px;
    }

    #items
    {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
        grid-row-gap: 32px;
    }
</style>