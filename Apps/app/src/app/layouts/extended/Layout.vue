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
        <Sidepanel/>
    </div>
</template>

<script lang='ts' setup>
    import Sidepanel from './sidepanel/Sidepanel.vue'
    import Sidebar from './sidebar/Sidebar.vue'
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
        grid-template-columns: 1fr min-content minmax(min-content, 800px) 280px min-content 1fr;
        grid-template-areas:
            "pane-left sidebar content sidepanel pane-right";
    }

    #sidepanel
    {
        grid-area: sidepanel;
        padding: 16px;
        border-left: 1px solid scale-color($background, $lightness: -5%);
        border-right: 1px solid scale-color($background, $lightness: -5%);
    }

    #sidebar
    {
        align-self: stretch;
        grid-area: sidebar;
        border-left: 1px solid scale-color($background, $lightness: -5%);
        border-right: 1px solid scale-color($background, $lightness: -5%);
    }

    #content
    {
        display: flex;
        align-self: stretch;
        grid-area: content;
        max-height: 100vh;
    }

    #cookies
    {
        position: absolute;
        bottom: 16px;
        left: 50%;
        transform: translateX(-50%);
    }
</style>