<template>
    <div id='editor'>
        <div id='input'>
            <h5 v-text='"Source"'/>
            <Textarea id='source' 
                autoresize 
                v-model='text'
            />
        </div>
        <div id='output'>
            <h5 v-text='"Preview"'/>
            <Markdown id='preview' 
                :source='text'
                :highlight='highlight'
                typographer
                linkify
            />
        </div>
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import 'highlight.js/scss/github-dark-dimmed.scss'

    const text = ref('')

    const highlight = (
    {
        hljs: require('highlight.js')
    })
</script>

<style lang='scss' scoped>
    #editor
    {
        display: grid;
        flex-grow: 1;
        align-self: stretch;
        justify-self: stretch;
        grid-column-gap: 16px;
        grid-template-columns: repeat(2, 1fr);
    }

    #input, #output
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 16px;
        overflow: auto;
    }

    #source
    {
        flex-grow: 1;
        padding: 16px;
    }

    #preview
    {
        flex-grow: 1;
        border: 1px solid black;
        border-radius: 3px;
        padding: 16px;
    }
</style>