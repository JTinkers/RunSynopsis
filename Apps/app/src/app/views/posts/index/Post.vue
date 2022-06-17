<template>
    <Panel class='post'>
        <div class='header'>
            <UserBadge class='user' :user='author'/>
            <span class='written-at' v-text='writtenAt'/>
        </div>
        <router-link class='title' 
            :to='route'
            v-text='title'
        />
        <Markdown class='content' :source='content'/>
    </Panel>
</template>

<script lang='ts' setup>
    import { PropType, computed, reactive } from 'vue'
    import { IPost } from '@/core/domain/api'
    import { formatDistance } from 'date-fns'

    const props = defineProps(
    {
        post: 
        {
            type: Object as PropType<IPost>,
            required: true,
        }
    })

    const 
    { 
        id, 
        title, 
        slug, 
        content, 
        author 
    } = reactive(props.post)

    const writtenAt = computed(() =>
    {
        const phrase = formatDistance(new Date(props.post.writtenAt), new Date(), 
        { 
            addSuffix: true
        })

        return phrase
    })

    const route = computed(() => 
    ({ 
        name: 'posts-view', 
        params: { id, slug } 
    }))
</script>

<style lang='scss' scoped>
    .post
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
    }

    .header
    {
        display: flex;
        align-items: flex-start;
        justify-content: space-between;
    }

    .title
    {
        font-weight: 800;
        font-size: 19px;
        line-height: 1.5;
        transition: all 0.2s ease-in-out;
        font-family: $font-family-primary;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }

    .content
    {
        display: -webkit-box;
        text-overflow: ellipsis;
        overflow: hidden;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 4;
    }

    .written-at
    {
        display: flex;
        grid-column-gap: 2px;
        align-items: center;
        color: scale-color($background, $lightness: -40%);
        font-size: 14px;
        font-family: $font-family-primary;
    }
</style>