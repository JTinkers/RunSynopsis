<template>
    <div class='note' :class='type'>
        <span class='icon material-symbols-outlined' v-text='icons[type]'/>
        <slot>
            <span class='text' v-text='text'/>
        </slot>
    </div>
</template>

<script lang='ts' setup>
    import { PropType } from 'vue'
    import { NoteType } from './NoteType'
    import { NoteIcon as icons } from './NoteIcon'

    defineProps(
    {
        text:
        {
            type: String,
        },
        type:
        {
            type: String as PropType<NoteType>,
            default: NoteType.Default
        },
    })
</script>

<style lang='scss' scoped>
    $types: ('primary', 'info', 'warning', 'success', 'error');

    $vars: 
    (
        primary-color: $background,
        primary-border: 1px solid scale-color($foreground, $lightness: 20%),
        primary-background: scale-color($foreground, $lightness: 5%),
        primary-icon-background: scale-color($foreground, $lightness: 15%),

        info-color: scale-color($blue, $lightness: -45%),
        info-border: 1px solid scale-color($blue, $lightness: 65%),
        info-background: scale-color($blue, $lightness: 85%),
        info-icon-background: scale-color($blue, $lightness: 75%),

        warning-color: scale-color($yellow, $lightness: -45%),
        warning-border: 1px solid scale-color($yellow, $lightness: 65%),
        warning-background: scale-color($yellow, $lightness: 85%),
        warning-icon-background: scale-color($yellow, $lightness: 75%),

        success-color: scale-color($green, $lightness: -45%),
        success-border: 1px solid scale-color($green, $lightness: 65%),
        success-background: scale-color($green, $lightness: 85%),
        success-icon-background: scale-color($green, $lightness: 75%),
        
        error-color: scale-color($red, $lightness: -45%),
        error-border: 1px solid scale-color($red, $lightness: 65%),
        error-background: scale-color($red, $lightness: 85%),
        error-icon-background: scale-color($red, $lightness: 75%),
    );

    .note
    {
        display: flex;
        grid-column-gap: 8px;
        align-items: center;
        color: $foreground;
        background: scale-color($background, $lightness: -5%);
        border: 1px solid scale-color($background, $lightness: -10%);
        border-radius: 256px;
        padding: 4px 16px 4px 4px;
    }

    .text
    {
        font-family: $font-family-secondary;
        font-size: 12px;
        white-space: nowrap;
    }

    .icon
    {
        padding: 4px;
        font-size: 20px;
        border-radius: 256px;
        background: scale-color($background, $lightness: -15%);
        font-variation-settings:
            'FILL' 0,
            'wght' 400,
            'GRAD' 100,
            'opsz' 100;
    }

    @each $type in $types
    {
        .note.#{$type}
        {
            color: map-get($vars, '#{$type}-color');
            background: map-get($vars, '#{$type}-background');
            border: map-get($vars, '#{$type}-border');

            .icon
            {
                background: map-get($vars, '#{$type}-icon-background');
            }
        }
    }
</style>