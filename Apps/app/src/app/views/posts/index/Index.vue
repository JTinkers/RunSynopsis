<template>
    <div id='posts-index'>
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
    #posts-index
    {
        display: flex;
        flex-grow: 1;
    }
</style>