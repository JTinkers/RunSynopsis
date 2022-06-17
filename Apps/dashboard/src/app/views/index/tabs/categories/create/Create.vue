<template>
    <div id='create'>
        <InputText placeholder='Name' v-model='form.name'/>
        <Textarea placeholder='Description' v-model='form.description'/>
        <Button label='Create' @click='create'/>
    </div>
</template>

<script lang='ts' setup>
    import { reactive } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import { createCategoryMutation } from './gql/createCategoryMutation'

    const api = useService<IApiService>('IApiService')

    const form = reactive(
    {
        name: '',
        description: ''
    })

    async function create()
    {
        await api.mutation(createCategoryMutation, { request: form })
    }
</script>

<style lang='scss' scoped>
    #create
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
        max-width: 400px;
    }
</style>