<template>
    <div class='category-badge'>
        <span class='name' v-text='name'/>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, reactive } from 'vue'
    import { ICategory } from '@/core/domain/api'

    const props = defineProps(
    {
        category:
        {
            type: Object as PropType<ICategory>,
            required: true
        }
    })

    const { name } = reactive(props.category)
</script>

<style lang='scss' scoped>
    .category-badge
    {
        display: flex;
        grid-column-gap: 4px;
        align-items: center;
        color: $foreground;
        background: scale-color($background, $lightness: -5%);
        padding: 8px 12px;
        border-radius: 256px;
    }
    
    .name
    {
        font-size: 12px;
        font-weight: 600;
        font-family: $font-family-secondary;
    }
</style>