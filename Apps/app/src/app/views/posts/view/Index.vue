<template>
    <div id='posts-view' :key='$route.path'>
        <AsyncLoader>
            <Transition name='fade'
                mode='out-in' 
                appear
            >
                <PostAsync/>
            </Transition>
        </AsyncLoader>
    </div>
</template>

<script lang='ts' setup>
    import PostAsync from './PostAsync.vue'
</script>

<style lang='scss' scoped>
    #posts-view
    {
        display: flex;
        flex-grow: 1;
        justify-content: center;
        grid-row-gap: 16px;
    }
</style>