<template>
    <aside id='sidepanel'>
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
    #sidepanel
    {
        display: grid;
        color: $foreground;
        align-self: stretch;
        grid-row-gap: 16px;
        grid-template-rows: repeat(4, min-content) 1fr;
        grid-template-areas:
        "search"
        "newsletter"
        "editors"
        "pages"
        "footer";
    }

    #search
    {
        grid-area: search;
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
        grid-area: pages;
    }

    #footer
    {
        grid-area: footer;
        align-self: flex-end;
    }
</style>