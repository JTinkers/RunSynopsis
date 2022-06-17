<template>
    <div id='search'>
        <div id='controls'>
            <span class='icon material-symbols-outlined' v-text='"search"'/>
            <InputField id='input'
                placeholder='Search' 
                ref='input' 
                type='text'
                v-model='query'
                @input='search'
                @blur='blur'
            />
        </div>
        <ResultsPanel :query='searchQuery'/>
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import { debounce } from '@/core/domain/plugins/debounce'
    import ResultsPanel from './ResultsPanel.vue'

    const query = ref('')
    const searchQuery = ref('')

    const blur = debounce(() =>
    {
        query.value = ''

        searchQuery.value = query.value
    }, 100)

    const search = debounce((e: InputEvent) => 
    {
        query.value = (e.target as HTMLInputElement)
            .value
            .toLowerCase()

        searchQuery.value = query.value
    }, 500)
</script>

<style lang='scss' scoped>
    #search
    {
        display: flex;
        flex-direction: column;
    }

    #controls
    {
        display: flex;
        flex-grow: 1;
        align-items: center;
        background: scale-color($background, $lightness: -5%);
        border-radius: 256px;
        cursor: pointer;
        overflow: hidden;
        height: 32px;
    }

    .icon
    {
        font-size: 18px;
        color: scale-color($background, $lightness: -35%);
        padding: 0px 0px 0px 8px;
    }

    #input
    {
        display: flex;
        width: 100%;
        
        :deep(.control)
        {
            border: none;
        }
    }
</style>