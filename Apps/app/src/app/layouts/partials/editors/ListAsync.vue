<template>
    <div id='list'>
        <div v-for='{ id, avatarUrl, homepageUrl, nickname, bio } in authors'
            :key='id'
            class='editor'
        >
            <div class='avatar'>
                <img :src='avatarUrl'>
            </div>
            <div class='description'>
                <a class='nickname' 
                    :href='homepageUrl!' 
                    v-text='nickname'
                />
                <p class='bio' v-text='bio'/>
            </div>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import { useService } from '@/core'
    import { getAuthorsQuery } from './gql/getAuthorsQuery'
    import { IAuthor, IApiService } from '@/core/domain/api'

    const api = useService<IApiService>('IApiService')
    const authors = ref<Array<IAuthor>>([])

    await fetch()

    async function fetch()
    {
        const result = await api.query(getAuthorsQuery)

        authors.value = result.authors
    }
</script>

<style lang='scss' scoped>
    #list
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 24px;
    }

    .editor
    {
        display: grid;
        flex-grow: 1;
        grid-column-gap: 8px;
        grid-template-columns: min-content 1fr;
        grid-template-areas: 
            "avatar description";
    }

    .avatar
    {
        display: flex;
        grid-area: avatar;
        overflow: hidden;
        
        > img
        {
            width: 32px;
            height: 32px;
            object-fit: cover;
            border-radius: 256px;
        }
    }

    .description
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 2px;
    }

    .nickname
    {
        grid-area: nickname;
        font-family: $font-family-secondary;
        font-weight: 500;
        font-size: 13px;
        transition: all 0.2s ease-in-out;
        cursor: pointer;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }

    .bio
    {
        grid-area: bio;
        font-family: $font-family-primary;
        font-size: 12px;
        line-height: 1.25;
    }
</style>