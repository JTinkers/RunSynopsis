<template>
    <div class='button' 
        :class='
        { 
            [type]: true,
            disabled: disabled
        }'
        @click='emit("click")'
    >
        <slot>
            <span class='label' v-text='text'/>
        </slot>
    </div>
</template>

<script lang='ts' setup>
    import { PropType } from 'vue'
    import { ButtonType } from './ButtonType'

    const emit = defineEmits(['click'])

    defineProps(
    {
        text: 
        {
            type: String,
            default: 'Label'
        },
        type:
        {
            type: String as PropType<ButtonType>
        },
        disabled:
        {
            type: Boolean,
            default: false
        }
    })
</script>

<style lang='scss' scoped>
    $types: ('primary', 'info', 'warning', 'success', 'error');

    $vars:
    (
        primary-color: $background,
        primary-background: scale-color($foreground, $lightness: 10%),
        primary-hover-background: scale-color($foreground, $lightness: 30%),
        primary-disabled-background: scale-color($foreground, $lightness: 50%),

        info-color: scale-color($blue, $lightness: -40%),
        info-background: scale-color($blue, $lightness: 55%),
        info-hover-background: scale-color($blue, $lightness: 25%),
        info-disabled-background: scale-color($blue, $lightness: 85%),

        warning-color: scale-color($yellow, $lightness: -40%),
        warning-background: scale-color($yellow, $lightness: 55%),
        warning-hover-background: scale-color($yellow, $lightness: 25%),
        warning-disabled-background: scale-color($yellow, $lightness: 85%),

        success-color: scale-color($green, $lightness: -40%),
        success-background: scale-color($green, $lightness: 55%),
        success-hover-background: scale-color($green, $lightness: 25%),
        success-disabled-background: scale-color($green, $lightness: 85%),
        
        error-color: scale-color($red, $lightness: -40%),
        error-background: scale-color($red, $lightness: 55%),
        error-hover-background: scale-color($red, $lightness: 25%),
        error-disabled-background: scale-color($red, $lightness: 85%),
    );

    .button
    {
        display: flex;
        min-height: 36px;
        justify-content: center;
        align-items: center;
        padding: 0 16px;
        border-radius: 5px;
        color: $foreground;
        background: scale-color($background, $lightness: -10%);
        cursor: pointer;
        transition: all 0.2s ease-in-out;

        &.disabled
        {
            pointer-events: none;
            background: scale-color($background, $lightness: -50%);
        }

        &:hover
        {
            background: scale-color($background, $lightness: -30%);
        }
    }

    .label
    {
        font-size: 13px;
        font-weight: 500;
        font-family: $font-family-secondary;
    }

    @each $type in $types
    {
        .button.#{$type}
        {
            background: map-get($vars, '#{$type}-background');
            color: map-get($vars, '#{$type}-color');

            &.disabled
            {
                pointer-events: none;
                background: map-get($vars, '#{$type}-disabled-background');
            }

            &:hover
            {
                background: map-get($vars, '#{$type}-hover-background');
            }
        }
    }
</style>