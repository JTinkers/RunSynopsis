<template>
    <div id='sidebar'>
        <Logo/>
        <Actions/>
    </div>
</template>

<script lang='ts' setup>
    import Actions from '@/app/layouts/partials/actions/Actions.vue'
</script>

<style lang='scss' scoped>
    #sidebar
    {
        display: flex;
        flex-direction: column;
    }

    #logo
    {
        $size: 24px;

        height: $size;
        width: $size;
        object-fit: contain;
        margin: 8px;
    }
</style>