<template>
    <div id='pages'>
        <router-link v-for='{ label, to } in routes'
            class='route'
            :key='label'
            :to='to'
            v-text='label'
        />
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import { IRoute } from './IRoute'

    const routes = ref<Array<IRoute>>(
    [
        {
            label: 'Posts',
            to: { name: 'posts-index' }
        },
        {
            label: 'Articles',
            to: { name: 'articles-index' }
        },
        {
            label: 'Our Cause',
            to: { name: 'our-cause' }
        },
        {
            label: 'Cookie Policy',
            to: { name: 'cookie-policy' }
        },
    ]);
</script>

<style lang='scss' scoped>
    #pages
    {
        display: grid;
        grid-template-rows: repeat(2, 1fr);
        grid-template-columns: repeat(2, 1fr);
        grid-auto-flow: column;
        grid-row-gap: 8px;
        grid-column-gap: 8px;
        padding: 16px;
        border-radius: 5px;
        background: scale-color($background, $lightness: -2.5%);
    }

    .route
    {
        font-size: 12px;
        font-family: $font-family-primary;
        transition: all 0.2s ease-in-out;
        white-space: nowrap;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }
</style>