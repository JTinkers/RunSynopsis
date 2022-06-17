<template>
    <div class='note-block' :class='type'>
        <div class='content'>
            <div class='icon-container'>
                <span class='icon material-symbols-outlined' v-text='icons[type]'/>
            </div>
            <slot>
                <p class='text' v-text='text'/>
            </slot>
        </div>
        <div v-if='decay > 0' class='decay'>
            <div class='decay-bar'/>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import { NoteType } from './NoteType'
    import { NoteIcon as icons } from './NoteIcon'
    import { PropType, ref, onUnmounted, onMounted, nextTick } from 'vue'

    const emit = defineEmits(['decayed'])

    let decayBarAnimCss = ref('auto')
    let decayBarWidthCss = ref('100%')
    let decayTimerId = ref(-1)

    const props = defineProps(
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
        decay:
        {
            type: Number,
            default: 0,
        }
    })

    function setupDecay()
    {
        decayBarAnimCss.value = (props.decay / 1000) + 's'
        decayBarWidthCss.value = '0%'
        decayTimerId.value = setTimeout(() => emit('decayed'), props.decay)
    }

    onMounted(() =>
    {
        if(props.decay) 
            setTimeout(() => setupDecay(), 100)
    })

    onUnmounted(() =>
    {
        clearTimeout(decayTimerId.value)
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

    .note-block
    {
        display: flex;
        flex-direction: column;
        color: $foreground;
        background: scale-color($background, $lightness: -5%);
        border: 1px solid scale-color($background, $lightness: -10%);
        border-radius: 3px;
        padding: 4px;
        grid-row-gap: 4px;
    }

    .content
    {
        display: flex;
        grid-column-gap: 8px;
        align-items: center;
    }

    .text
    {
        font-family: $font-family-secondary;
        font-size: 12px;
        line-height: 1.5;
        white-space: pre-wrap;
    }

    .icon-container
    {
        display: flex;
        padding: 4px;
        border-radius: 3px;
        align-self: stretch;
        align-items: center;
        background: scale-color($background, $lightness: -15%);
    }

    .icon
    {
        font-size: 20px;
        font-variation-settings:
            'FILL' 0,
            'wght' 400,
            'GRAD' 100,
            'opsz' 100;
    }

    .decay
    {
        display: flex;
        background: scale-color($background, $lightness: -15%);
        height: 3px;
    }

    .decay-bar
    {
        background: $foreground;
        height: 100%;
        width: v-bind(decayBarWidthCss);
        transition: width v-bind(decayBarAnimCss) linear;
    }

    @each $type in $types
    {
        .note-block.#{$type}
        {
            color: map-get($vars, '#{$type}-color');
            background: map-get($vars, '#{$type}-background');
            border: map-get($vars, '#{$type}-border');

            .decay
            {
                background: map-get($vars, '#{$type}-icon-background');
            }

            .decay-bar
            {
                background: map-get($vars, '#{$type}-color');
            }

            .icon-container
            {
                background: map-get($vars, '#{$type}-icon-background');
            }
        }
    }
</style>