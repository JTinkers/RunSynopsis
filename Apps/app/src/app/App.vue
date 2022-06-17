<template>
    <Component :is='layout'/>
    <Cookies/>
</template>

<script lang='ts' setup>
    import LayoutExtended from './layouts/extended/Layout.vue'
    import LayoutCompact from './layouts/compact/Layout.vue'
    import Cookies from './layouts/partials/Cookies.vue'
    import { debounce } from '@/core/domain/plugins/debounce'
    import { onMounted, shallowRef } from 'vue'

    const compactBreakpoint = 1000
    let layout = shallowRef(LayoutExtended)

    function handleResize()
    {
        const isCompact = window.innerWidth <= compactBreakpoint

        layout.value = isCompact ? LayoutCompact : LayoutExtended
    }

    window.addEventListener('resize', debounce(handleResize, 250))

    onMounted(() => handleResize())
</script>

<style lang='scss'>
    #app
    {
        display: flex;
        height: 100vh;
        width: 100vw;
    }
</style>

<style lang='scss' scoped>
    #cookies
    {
        position: absolute;
        bottom: 16px;
        left: 50%;
        transform: translateX(-50%);
    }
</style>