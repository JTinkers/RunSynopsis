<template>
    <div id='articles-view' :key='$route.path'>
        <AsyncLoader>
            <Transition name='fade'
                mode='out-in' 
                appear
            >
                <ArticleAsync/>
            </Transition>
        </AsyncLoader>
    </div>
</template>

<script lang='ts' setup>
    import ArticleAsync from './ArticleAsync.vue'
</script>

<style lang='scss' scoped>
    #articles-view
    {
        display: flex;
        flex-direction: column;
        flex-grow: 1;
        grid-row-gap: 16px;
    }
</style>