<template>
    <div id='profile'>
        <InputText id='avatarUrl' 
            placeholder='Avatar Url'
            v-model='form.avatarUrl'
        />
        <InputText id='homepageUrl' 
            placeholder='Homepage Url'
            v-model='form.homepageUrl'
        />
        <InputText id='bio' 
            placeholder='Bio'
            v-model='form.bio'
        />
        <InputText id='password' 
            type='password' 
            placeholder='Password'
            v-model='form.password'
        />
        <Button label='Save' @click='save'/>
    </div>
</template>

<script lang='ts' setup>
    import { reactive, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import { updateUserMutation } from './gql/updateUserMutation'

    const api = useService<IApiService>('IApiService')
    const userId = api.user!.id

    const form = reactive(
    {
        homepageUrl: null,
        avatarUrl: null,
        bio: null,
        password: null
    } as any)

    async function save()
    {
        await api.mutation(updateUserMutation, 
        { 
            userId, 
            request: form 
        })
    }

    onMounted(() =>
    {
        form.bio = api.user!.bio
        form.avatarUrl = api.user!.avatarUrl
        form.homepageUrl = api.user!.homepageUrl
    })
</script>

<style lang='scss' scoped>
    #profile
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
    }
</style>