<template>
    <div class='user-badge'>
        <div class='avatar'>
            <img :src='avatarUrl'>
        </div>
        <span class='nickname' v-text='nickname'/>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, toRef, reactive } from 'vue'
    import { IAuthor } from '@/core/domain/api'

    const props = defineProps(
    {
        user: 
        {
            type: Object as PropType<IAuthor>,
            required: true
        }
    })

    const { nickname } = reactive(props.user) 
    
    const avatarUrl = toRef(props.user, 'avatarUrl')
    avatarUrl.value = avatarUrl.value ?? '/images/self.png'
</script>

<style lang='scss' scoped>
    .user-badge
    {
        display: flex;
        grid-column-gap: 6px;
        align-items: center;
        color: $foreground;
        cursor: pointer;
        transition: all 0.2s ease-in-out;
        overflow: hidden;

        &:hover
        {
            color: scale-color($orange, $lightness: -20%);
        }
    }

    .nickname
    {
        font-size: 13px;
        font-weight: 500;
        font-family: $font-family-secondary;
    }
    
    .avatar
    {
        display: flex;
        overflow: hidden;
        
        > img
        {
            width: 26px;
            height: 26px;
            object-fit: cover;
            border-radius: 256px;
        }
    }
</style>