<template>
    <BaseInput v-bind='$attrs' 
        v-slot='{ props, value, onInput, onBlur }'
    >
        <textarea :name='props.name'
            :placeholder='props.placeholder'
            :value='value'
            :rows='rows'
            @input='onInput'
            @blur='onBlur'
        />
    </BaseInput>
</template>

<script lang='ts' setup>
    import Input from './Input.vue'

    defineProps(
    {
        rows: 
        {
            type: Number,
            default: 4
        }
    })
</script>

<style lang='scss' scoped>
    textarea
    {
        display: flex;
        color: $foreground;
        flex-grow: 1;
        outline: none;
        border: none;
        background: none;
        font-family: $font-family-primary;
        font-size: 14px;
        line-height: 1.25;
        margin: 0;
        padding: 8px;
        max-width: 100%;
        height: 100%;
        resize: none;

        &::placeholder
        {
            color: scale-color($background, $lightness: -35%);
        }
    }
</style>