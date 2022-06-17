<template>
    <BaseInput v-bind='$attrs' 
        v-slot='{ props, value, onInput, onBlur }'
    >
        <input :type='props.type' 
            :name='props.name'
            :placeholder='props.placeholder'
            :value='value'
            @input='(e) => input(e, onInput)'
            @blur='(e) => blur(e, onBlur)'
        >
    </BaseInput>
</template>

<script lang='ts' setup>
    import Input from './Input.vue'

    const emit = defineEmits(['input', 'blur'])

    function input(e: any, baseInput: (e: any) => void)
    {
        baseInput(e)

        emit('input', e)
    }

    function blur(e: any, baseBlur: (e: any) => void)
    {
        baseBlur(e)

        emit('blur', e)
    }
</script>

<style lang='scss' scoped>
    input
    {
        color: $foreground;
        flex-grow: 1;
        outline: none;
        border: none;
        background: none;
        font-family: $font-family-primary;
        font-size: 14px;
        margin: 0;
        padding: 0 8px;
        width: 100%;

        &::placeholder
        {
            color: scale-color($background, $lightness: -35%);
        }
    }
</style>