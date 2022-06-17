<template>
    <Panel id='post-header'>
        <div id='header'>
            <UserBadge id='author' :user='author'/>
            <CategoryBadge id='category' :category='category'/>
        </div>
        <span id='title' v-text='title'/>
        <Markdown id='content' :source='content'/>
        <div id='tags'>
            <TagBadge v-for='tag in tags'
                :key='tag.id'
                :tag='tag'
            />
        </div>
    </Panel>
</template>

<script lang='ts' setup>
    import { PropType, reactive } from 'vue'
    import { IPost } from '@/core/domain/api'

    const props = defineProps(
    {
        post: 
        {
            type: Object as PropType<IPost>,
            required: true
        }
    })

    const 
    { 
        title, 
        content, 
        author, 
        category, 
        tags
    } = reactive(props.post!)
</script>

<style lang='scss' scoped>
    #post-header
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
    }

    #header
    {
        display: flex;
    }

    #title
    {
        font-family: $font-family-primary;
        font-size: 19px;
        font-weight: 800;
        line-height: 1.5;
    }

    #category
    {
        margin-left: auto;
    }

    #author
    {
        display: flex;
        align-self: flex-start;
    }

    #content
    {
        font-size: 16px;
        line-height: 1.5;
    }

    #tags
    {
        display: flex;
        flex-wrap: wrap;
        grid-gap: 8px;
    }
</style>