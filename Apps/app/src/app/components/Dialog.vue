<template>
    <div v-if='show' class='backdrop'>
        <div class='dialog' v-bind='$attrs'>
            <div class='header'>
                <span v-if='icon'
                    class='icon material-symbols-outlined' 
                    v-text='icon'
                />
                <span class='title' v-text='title'/>
                <IconButton v-if='closable'
                    class='close' 
                    icon='close'
                    @click='close'
                />
            </div>
            <slot/>
        </div>
    </div>
</template>

<script lang='ts'>
    export default
    {
        inheritAttrs: false
    }
</script>

<script lang='ts' setup>
    import { computed, useAttrs } from 'vue'

    const emit = defineEmits(['update:show'])

    const attrs = useAttrs()

    defineProps(
    {
        title:
        {
            type: String,
            default: 'Dialog',
        },
        icon:
        {
            type: String,
            required: false,
        },
        closable:
        {
            type: Boolean,
            default: true,
        },
    })

    const show = computed(
    {
        get()
        {
            return attrs.show as boolean
        },
        set(value: boolean)
        {
            emit('update:show', value)
        }
    })

    function close() 
    { 
        show.value = false
    }
</script>

<style lang='scss' scoped>
    .backdrop
    {
        display: flex;
        align-items: center;
        justify-content: center;
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        z-index: 1000;
        background: rgba(0, 0, 0, 0.5);
        transition: all 0.2s ease-in-out;
    }

    .dialog
    {
        display: flex;
        grid-row-gap: 16px;
        flex-direction: column;
        color: $foreground;
        background: $background;
        border-radius: 3px;
        padding: 16px;
        transition: all 0.2s ease-in-out;
    }

    .header
    {
        display: flex;
        grid-column-gap: 4px;
        align-items: center;
    }

    .title
    {
        font-size: 14px;
        font-family: $font-family-secondary;
        font-weight: 500;
    }

    .icon
    {
        font-size: 18px;
        font-variation-settings:
            'FILL' 0,
            'wght' 400,
            'GRAD' 0,
            'opsz' 18;
    }

    .close
    {
        margin-left: auto;
        padding: 4px !important;
    }
</style>