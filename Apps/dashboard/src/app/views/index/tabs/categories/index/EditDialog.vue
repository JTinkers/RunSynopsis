<template>
    <Dialog ref='dialog' 
        v-bind='$attrs' 
        modal
    >
        <div id='inputs'>
            <InputText placeholder='Name' v-model='form.name'/>
            <Textarea placeholder='Description' 
                id='description' 
                v-model='form.description'
            />
            <Button label='Save' @click='save'/>
        </div>
    </Dialog>
</template>

<script lang='ts' setup>
    import { PropType, reactive, ref, watch } from 'vue'
    import { useService } from '@/core'
    import { IApiService, ICategory } from '@/core/domain/api'
    import { updateCategoryMutation } from './gql/updateCategoryMutation'
    import Dialog from 'primevue/dialog'

    const api = useService<IApiService>('IApiService')
    const dialog = ref<Dialog>()

    const props = defineProps(
    {
        category:
        {
            type: Object as PropType<ICategory>,
            required: true,
        },
    })

    const form = reactive(
    {
        name: '',
        description: '',
    })

    async function save()
    {
        await api.mutation(updateCategoryMutation, { request: { id: props.category.id, ...form } })

        dialog.value?.$emit('update:visible', false)
    }

    watch(() => props.category, async () =>
    {
        form.name = props.category.name
        form.description = props.category.description
    }, { immediate: true })
</script>

<style lang='scss' scoped>
    #inputs
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
        min-width: 400px;
        min-height: 200px;
    }

    #description
    {
        flex-grow: 1;
    }
</style>