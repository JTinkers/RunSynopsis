<template>
    <Panel class='article'>
        <div class='image'>
            <img :src='headerSrc'>
        </div>
        <CategoryBadge class='category' :category='category'/>
        <router-link class='title' 
            :to='route'
            v-text='title'
        />
        <p class='synopsis' v-text='synopsis'/>
        <div class='tags'>
            <TagBadge v-for='tag in tags'
                class='tag' 
                :key='tag.id'
                :tag='tag'
            />
        </div>
    </Panel>
</template>

<script lang='ts' setup>
    import { PropType, reactive, computed } from 'vue'
    import { IArticle } from '@/core/domain/api'

    const props = defineProps(
    {
        article: 
        {
            type: Object as PropType<IArticle>,
            required: true,
        }
    })

    const 
    { 
        id, 
        tags, 
        title, 
        headerSrc, 
        slug, 
        synopsis, 
        category 
    } = reactive(props.article)

    tags.sort((a, b) => b.name.length - b.name.length)

    const route = computed(() => 
    ({ 
        name: 'articles-view', 
        params: { id, slug } 
    }))
</script>

<style lang='scss' scoped>
    .article
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
        overflow: hidden;
    }

    .title
    {
        font-weight: 800;
        font-size: 19px;
        font-family: $font-family-primary;
        line-height: 1.5;
        transition: all 0.2s ease-in-out;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }

    .image
    {
        display: flex;
        overflow: hidden;
        max-height: 384px;

        img
        {
            width: 100%;
            object-fit: cover;
            object-position: center;
        }
    }

    .synopsis
    {
        display: -webkit-box;
        text-overflow: ellipsis;
        font-size: 16px;
        overflow: hidden;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 4;
        line-height: 1.75;
    }

    .category
    {
        align-self: flex-start;
    }

    .tags
    {
        display: flex;
        grid-gap: 8px;
        flex-wrap: wrap;
    }
</style>