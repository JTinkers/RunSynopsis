<template>
    <div v-if='query.length' id='container'>
        <Panel id='results-panel'>
            <div id='header'>
                <span id='title' v-text='"Results"'/>
                <p id='description' v-text='`${total} items found`'/>
            </div>
            <AsyncLoader>
                <Transition name='fade'
                    mode='out-in' 
                    appear
                >
                    <ResultsAsync :query='query' @found='found'/>
                </Transition>
            </AsyncLoader>
        </Panel>
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import ResultsAsync from './ResultsAsync.vue'

    defineProps(
    {
        query:
        {
            type: String,
            required: true
        }
    })

    const total = ref(0)

    function found(count: number)
    {
        total.value = count
    }
</script>

<style lang='scss' scoped>
    #container
    {
        display: flex;
        position: relative;
    }

    #results-panel
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        background: $background;
        box-shadow: rgba(0, 0, 0, 0.1) 0px 8px 32px 0px;
        font-family: $font-family-secondary;
        min-width: 100%;
        padding: 16px;
        position: absolute;
        top: 8px;
        right: 0;
        z-index: 1000;
        overflow: hidden;
    }

    #header
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 4px;
    }

    #title
    {
        font-size: 14px;
        font-weight: 500;
    }

    #description
    {
        font-size: 12px;
        line-height: 1;
    }

    :deep(.indicator)
    {
        margin-top: 8px;
    }

    #results
    {
        min-width: 400px;
    }
</style>