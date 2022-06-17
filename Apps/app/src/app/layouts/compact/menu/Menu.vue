<template>
    <aside id='menu'>
        <Search/>
        <Newsletter/>
        <Editors/>
        <Routes/>
        <Footer/>
    </aside>
</template>

<script lang='ts' setup>
    import Search from '@/app/layouts/partials/search/Search.vue'
    import Editors from '@/app/layouts/partials/editors/Editors.vue'
    import Newsletter from '@/app/layouts/partials/newsletter/Newsletter.vue'
    import Routes from '@/app/layouts/partials/routes/Routes.vue'
    import Footer from '@/app/layouts/partials/Footer.vue'
</script>

<style lang='scss' scoped>
    #menu
    {
        display: grid;
        color: $foreground;
        background: $background;
        align-self: stretch;
        grid-gap: 16px;
        overflow-y: auto;
        grid-template-rows: repeat(3, min-content) 1fr;
        grid-template-areas:
        "search search"
        "editors editors"
        "pages newsletter"
        "footer footer";
    }

    #search
    {
        grid-area: search;

        :deep(#results)
        {
            min-width: auto;
        }
    }

    #editors
    {
        grid-area: editors;
    }

    #newsletter
    {
        grid-area: newsletter;
    }

    #pages
    {
        grid-area: pages
    }

    #footer
    {
        grid-area: footer;
        align-self: flex-end
    }
</style>