<template>
    <div id='post'>
        <div id='dates'>
            <span id='written-at' v-text='writtenAt'/>
            <span id='updated-at' v-text='updatedAt'/>
        </div>
        <Header :post='post'/>
    </div>
</template>

<script lang='ts' setup>
    import Header from './Header.vue'
    import { computed, ref, reactive } from 'vue'
    import { useRoute } from '@/core/domain/router'
    import { useService } from '@/core'
    import { IPost, IApiService } from '@/core/domain/api'
    import { getPostQuery } from './gql/getPostQuery'
    import { formatDistance } from 'date-fns'

    const api = useService<IApiService>('IApiService')
    const route = useRoute()

    const post = ref<IPost>()
    post.value = await fetch()

    async function fetch()
    {
        return (await api.query(getPostQuery, 
        { 
            id: route.params.id 
        }))
        .post
    }

    const writtenAt = computed(() =>
    {
        const phrase = formatDistance(new Date(post.value!.writtenAt), new Date(), 
        { 
            addSuffix: true
        })

        return 'Written ' + phrase
    })

    const updatedAt = computed(() =>
    {
        const phrase = formatDistance(new Date(post.value!.writtenAt), new Date(), 
        { 
            addSuffix: true
        })

        return 'Edited ' + phrase
    })
</script>

<style lang='scss' scoped>
    #post
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 32px;
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
</style>