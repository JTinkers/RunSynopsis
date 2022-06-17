<template>
    <div id='layout'>
        <Sidebar/>
        <main id='content'>
            <RouterView v-slot='{ Component }'>
                <Transition name='fade'
                    mode='out-in' 
                    appear
                >
                    <Component :is='Component'/>
                </Transition>
            </RouterView>
        </main>
    </div>
    <Transition name='fade'
        mode='out-in' 
        appear
    >
        <Menu v-show='showMenu'/>
    </Transition>
    <IconButton id='menu-button' 
        icon='menu'
        @click='showMenu = !showMenu'
    />
</template>

<script lang='ts' setup>
    import Sidebar from './sidebar/Sidebar.vue'
    import Menu from './menu/Menu.vue'
    import { ref } from 'vue'
    import { useRouter } from 'vue-router'

    const router = useRouter()
    const showMenu = ref(false)

    router.afterEach(() => showMenu.value = false)
</script>

<style lang='scss' scoped>
    #layout
    {
        align-items: flex-start;
        flex-grow: 1;
        background: $background;
        color: $foreground;
        display: grid;
        overflow: hidden;
        grid-template-columns: min-content 1fr;
        grid-template-areas:
            "sidebar content";
    }

    #sidebar
    {
        align-self: stretch;
        grid-area: sidebar;
        border-right: 1px solid scale-color($background, $lightness: -5%);
    }

    #content
    {
        display: flex;
        align-self: stretch;
        grid-area: content;
        max-height: 100vh;
    }

    #menu-button
    {
        position: fixed;
        height: 32px;
        right: 8px;
        bottom: 8px;
        background: $foreground;
        color: $background;
        z-index: 3000;
    }

    #menu
    {
        position: fixed;
        flex-grow: 1;
        height: 100%;
        width: 100%;
        padding: 16px;
        background: $background;
        z-index: 2000;
    }
</style>