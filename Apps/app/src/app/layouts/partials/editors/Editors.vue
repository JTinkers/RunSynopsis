<template>
    <div id='editors'>
        <span id='title' v-text='"Editors"'/>
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
    #editors
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
        border-radius: 5px;
        background: scale-color($background, $lightness: -2.5%);
    }

    #title
    {
        font-size: 11px;
        font-family: $font-family-secondary;
        letter-spacing: 1px;
        text-transform: uppercase;
    }
</style>