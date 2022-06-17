<template>
    <div :class='`tooltip-container align-${axis}`'>
        <div class='wrapper'>
            <div :class='`tooltip align-${align}`'>
                <slot name='content'>
                    <span class='text' v-text='text'/>
                </slot>
            </div>
        </div>
        <div class='activator' 
            @mouseover='onMouseOver'
            @mouseleave='onMouseLeave'
        >
            <slot/>
        </div>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, ref, computed, reactive } from 'vue'
    import { TooltipAlignment } from './TooltipAlignment'

    const emit = defineEmits(['update:show'])

    const props = defineProps(
    {
        text:
        {
            type: String,
            default: 'Tooltip'
        },
        align:
        {
            type: String as PropType<TooltipAlignment>,
            default: TooltipAlignment.Top
        },
        margin:
        {
            type: Number,
            default: 4
        },
        show:
        {
            type: Boolean,
            default: undefined
        }
    })

    const { text, align } = reactive(props)

    const showInternal = ref(props.show ?? false)

    const show = computed(
    {
        get()
        {
            return (props.show ?? showInternal.value) as boolean
        },
        set(value: boolean)
        {
            showInternal.value = value

            emit('update:show', value)
        }
    })

    const axis = computed(() =>
    {
        return ['top, bottom'].indexOf(props.align) 
            ? 'vertical'
            : 'horizontal'
    })

    const showCss = computed(() =>
    {
        return show.value
            ? 'visible'
            : 'hidden'
    })

    const flexDirectionCss = computed(() =>
    {
        switch (align) 
        {
            case TooltipAlignment.Top:
                return 'column'
            case TooltipAlignment.Bottom:
                return 'column-reverse'
            case TooltipAlignment.Left:
                return 'row'
            case TooltipAlignment.Right:
                return 'row-reverse'
        }
        
        return ''
    })

    const marginCss = computed(() =>
    {
        return props.margin + 'px'
    })

    async function onMouseOver()
    {
        show.value = true
    }

    async function onMouseLeave()
    {
        show.value = false
    }
</script>

<style lang='scss' scoped>
    .tooltip-container 
    { 
        display: flex;
        flex-direction: v-bind(flexDirectionCss);
    }

    .activator
    {
        display: contents;
    }

    .wrapper
    {
        position: relative;
    }

    .tooltip
    {
        display: flex;
        visibility: v-bind(showCss);
        position: absolute;
        padding: 6px;
        z-index: 1000;
        background: $foreground;
        border-radius: 3px;
        box-shadow: rgba(0, 0, 0, 0.25) 0px 8px 16px 0px;

        &.align-top
        {
            bottom: 0;
            left: 50%;
            transform: translateX(-50%);
            margin-bottom: v-bind(marginCss);
        }

        &.align-bottom
        {
            top: 0;
            left: 50%;
            transform: translateX(-50%);
            margin-top: v-bind(marginCss);
        }

        &.align-left
        {
            right: 0;
            top: 50%;
            transform: translateY(-50%);
            margin-right: v-bind(marginCss);
        }

        &.align-right
        {
            left: 0;
            top: 50%;
            transform: translateY(-50%);
            margin-left: v-bind(marginCss);
        }
    }

    .text
    {
        color: $background;
        font-size: 11px;
        font-family: $font-family-secondary;
        white-space: pre;
    }
</style>