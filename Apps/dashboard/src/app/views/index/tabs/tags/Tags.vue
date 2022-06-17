<template>
    <div id='tags'>
        <Panel header='Add' 
            toggleable 
            collapsed
        >
            <Create/>
        </Panel>
        <Panel header='Index' 
            toggleable 
            collapsed
        >
            <Index/>
        </Panel>
    </div>
</template>

<script lang='ts' setup>
    import Index from './index/Index.vue'
    import Create from './create/Create.vue'
</script>

<style lang='scss' scoped>
    #tags
    {
        flex-grow: 1;
    }
</style>