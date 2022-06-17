<template>
    <div id='articles-index'>
        <AsyncLoader>
            <Transition name='fade'
                mode='out-in' 
                appear
            >
                <ListAsync/>
            </Transition>
        </AsyncLoader>
    </div>
</template>

<script lang='ts' setup>
    import ListAsync from './ListAsync.vue'
</script>

<style lang='scss' scoped>
    #articles-index
    {
        display: flex;
        flex-grow: 1;
    }
</style>