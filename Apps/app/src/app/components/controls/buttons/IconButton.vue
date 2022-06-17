<template>
    <Button class='icon-button' :type='type'>
        <span :class='iconType' v-text='icon'/>
    </Button>
</template>

<script lang='ts' setup>
    import { PropType } from 'vue'
    import { ButtonType } from './ButtonType'
    import { IconType } from './IconType'

    defineProps(
    {
        icon:
        {
            type: String,
            default: '',
        },
        type:
        {
            type: String as PropType<ButtonType>
        },
        iconType:
        {
            type: String as PropType<IconType>,
            default: IconType.Outlined
        }
    })
</script>

<style lang='scss' scoped>
    .icon-button
    {
        justify-self: flex-start;
        border-radius: 256px;
        min-height: 36px;
        min-width: 36px;
        padding: 0;

        span
        {
            font-size: 18px;
            font-variation-settings:
                'FILL' 0,
                'wght' 300,
                'GRAD' 0,
                'opsz' 18;
        }
    }
</style>