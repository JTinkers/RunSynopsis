<template>
    <div class='tag-badge'>
        <span class='icon material-symbols-outlined' v-text='"fiber_manual_record"'/>
        <span class='name' v-text='name'/>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, reactive } from 'vue'
    import { ITag } from '@/core/domain/api'

    const props = defineProps(
    {
        tag:
        {
            type: Object as PropType<ITag>,
            required: true
        }
    })

    const { name } = reactive(props.tag)
</script>

<style lang='scss' scoped>
    .tag-badge
    {
        display: flex;
        align-items: center;
        grid-column-gap: 4px;
        color: $foreground;
        background: scale-color($background, $lightness: -5%);
        padding: 8px;
        border-radius: 5px;
    }

    .icon
    {
        font-size: 12px;
    }
    
    .name
    {
        font-size: 12px;
        font-weight: 600;
        font-family: $font-family-secondary;
    }
</style>