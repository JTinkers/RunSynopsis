<template>
    <div class='spinner'>
        <div/>
        <div/>
    </div>
</template>

<script lang='ts' setup>
    import { computed } from 'vue'

    const props = defineProps(
    {
        size: 
        {
            type: Number,
            default: 32
        },
        width:
        {
            type: Number,
            default: 2
        },
    })

    const spinnerSize = computed(() =>
    {
        return props.size + 'px'
    })

    const spinnerWidth = computed(() =>
    {
        return props.width + 'px'
    })
</script>

<style lang='scss' scoped>
    @keyframes spinner 
    {
        0%
        {
            top: calc(v-bind(spinnerSize) / 2);
            left: calc(v-bind(spinnerSize) / 2);
            width: 0;
            height: 0;
            opacity: 1;
        }
        100% 
        {
            top: 0px;
            left: 0px;
            width: v-bind(spinnerSize);
            height: v-bind(spinnerSize);
            opacity: 0;
        }
    }

    .spinner 
    {
        width: v-bind(spinnerSize);
        height: v-bind(spinnerSize);
        position: relative;
        transform: translateZ(0) scale(1);
        backface-visibility: hidden;
        transform-origin: 0 0;
    }
    
    .spinner div 
    {
        position: absolute;
        border-width: v-bind(spinnerWidth);
        border-style: solid;
        opacity: 1;
        border-radius: 50%;
        animation: spinner 2s cubic-bezier(0, 0.2, 0.8, 1) infinite;
    }
    
    .spinner div:nth-child(1) 
    {
        border-color: #404040;
        animation-delay: 0s;
    }
    
    .spinner div:nth-child(2) 
    {
        border-color: #404040;
        animation-delay: -1s;
    }

    .spinner div 
    {
        box-sizing: content-box; 
    }

    /* generated by https://loading.io/ */
</style>