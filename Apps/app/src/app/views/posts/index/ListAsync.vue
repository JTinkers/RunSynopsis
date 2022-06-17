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
                <Post v-for='post in posts'
                    class='post'  
                    :key='post.id' 
                    :post='post'
                />
            </TransitionGroup>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import Post from './Post.vue'
    import { ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IPost, IApiService, IPageInfo } from '@/core/domain/api'
    import { getPostsQuery } from './gql/getPostsQuery'

    const api = useService<IApiService>('IApiService')
    const limit = 20
    const posts = ref<Array<IPost>>([])
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

        const response = (await api.query(getPostsQuery, 
        { 
            first: first,
            last: last,
            after: after,
            before: before,
        }))
        .response

        posts.value.push(...response.posts)

        pageInfo.value = response.pageInfo

        isLoading.value = false
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
        width: 100%;
        padding: 32px;
        overflow: auto;
    }

    #items
    {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
        grid-row-gap: 32px;
    }
</style>