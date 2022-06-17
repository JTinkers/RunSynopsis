<template>
    <Panel id='article-header'>
        <div id='image'>
            <img :src='headerSrc'>
            <div id='rt-wrapper'>
                <div id='rt'>
                    <span id='rt-icon' 
                        class='material-symbols-outlined' 
                        v-text='"timer"'
                    />
                    <span v-text='rt'/>
                </div>
            </div>
        </div>
        <div id='header'>
            <UserBadge id='author' :user='author'/>
            <CategoryBadge id='category' :category='category'/>
        </div>
        <span id='title' v-text='title'/>
        <span id='synopsis' v-text='synopsis'/>
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
    import { IArticle } from '@/core/domain/api'

    const props = defineProps(
    {
        article:
        {
            type: Object as PropType<IArticle>,
            required: true
        }
    })

    const 
    { 
        title,
        headerSrc,
        synopsis,
        author, 
        category, 
        tags,
        readTimeMinutes: rt
    } = reactive(props.article!)
</script>

<style lang='scss' scoped>
    #article-header
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
    }

    #image
    {
        display: flex;
        max-height: 384px;

        img
        {
            width: 100%;
            object-fit: cover;
            object-position: center;
        }
    }

    #rt-wrapper
    {
        position: relative;
    }

    #rt
    {
        position: absolute;
        top: 8px;
        right: 8px;
        display: flex;
        align-self: flex-end;
        grid-column-gap: 2px;
        padding: 8px;
        border-radius: 3px;
        background: scale-color($background, $lightness: -2.5%);
        font-size: 14px;
        font-family: $font-family-primary;
    }

    #rt-icon
    {
        font-size: 14px;
        font-variation-settings:
            'FILL' 0,
            'wght' 600,
            'GRAD' 400,
            'opsz' 100
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

    #synopsis
    {
        font-size: 16px;
        line-height: 1.75;
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