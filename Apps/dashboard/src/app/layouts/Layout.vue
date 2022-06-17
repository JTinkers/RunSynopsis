<template>
    <div id='layout'>
        <Nav/>
        <div id='content'>
            <RouterView/>
        </div>
        <div id='footer'>
            <span v-text='`Note: the temporary dashboard is not pretty... but it works!`'/>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import Nav from './nav/Nav.vue'
</script>

<style lang='scss' scoped>
    #layout
    {
        display: grid;
        flex-grow: 1;
        overflow: hidden;
        grid-template-rows: min-content 1fr min-content;
        grid-template-areas: 
            'nav'
            'content'
            'footer';
    }

    #nav
    {
        grid-area: nav;
    }

    #content
    {
        display: flex;
        overflow: auto;
    }

    #footer
    {
        font-size: 10px;
        letter-spacing: 1px;
        text-transform: uppercase;
        padding: 8px;
        background: black;
        color: white;
    }
</style>