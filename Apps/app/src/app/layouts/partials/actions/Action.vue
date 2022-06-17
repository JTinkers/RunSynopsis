<template>
    <Tooltip :align='TooltipAlignment.Right' :text='label'>
        <div 
            class='action'
            :class='{ active }'
            :key='label' 
            @click='onClick'
        >
            <span class='icon' 
                :class='iconClass ?? "material-symbols-outlined"' 
                v-text='icon'
            />
        </div>
    </Tooltip>
</template>

<script lang='ts' setup>
    import { PropType, reactive, computed } from 'vue'
    import { TooltipAlignment } from '@/app/components/tooltips/TooltipAlignment'
    import { IAction } from './IAction'

    const props = defineProps(
    {
        action: 
        {
            type: Object as PropType<IAction>,
            required: true
        }
    })

    const 
    { 
        onClick, 
        label, 
        icon, 
        iconClass, 
        isActive,
    } = reactive(props.action)

    const active = computed(() =>
    {
        if (!isActive)
            return false

        return isActive()
    })
</script>

<style lang='scss' scoped>
    .action
    {
        display: flex;
        padding: 8px;
        color: scale-color($background, $lightness: -40%);
        background: $background;
        transition: color 0.2s ease-in-out;
        cursor: pointer;
        border-bottom: 1px solid scale-color($background, $lightness: -5%);

        &:hover
        {
            color: $foreground;
            border-right: 2px solid $foreground;
            padding-right: 6px;
        }

        &.active
        {
            color: scale-color($orange, $lightness: -20%);
            border-right: 2px solid scale-color($orange, $lightness: -20%);
            padding-right: 6px;
        }
    }

    .icon
    {
        font-size: 24px;
        font-variation-settings:
            'FILL' 0,
            'wght' 200,
            'GRAD' 0,
            'opsz' 24;
    }
</style>