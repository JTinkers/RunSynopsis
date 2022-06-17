<template>
    <DataTable :value='categories'>
        <Column field='id' header='Id'/>
        <Column field='name' 
            header='Name' 
            sortable
        />
        <Column field='description' header='Description'/>
        <Column header='Actions'>
            <template #body='props'>
                <div id='actions'>
                    <Button label='Remove' @click='remove(props.data.id)'/>
                    <Button label='Edit' @click='edit(props.data.id)'/>
                </div>
            </template>
        </Column>
        <EditDialog v-if='selectedCategory' 
            :category='selectedCategory' 
            v-model:visible='showEditDialog'
        />
    </DataTable>
</template>

<script lang='ts' setup>
    import EditDialog from './EditDialog.vue'
    import { computed, ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IApiService, ICategory } from '@/core/domain/api'
    import { getCategoriesQuery } from './gql/getCategoriesQuery'
    import { removeCategoryMutation } from './gql/removeCategoryMutation'

    const api = useService<IApiService>('IApiService')
    const categories = ref<Array<ICategory>>([])
    const selected = ref<string| null>(null)
    const showEditDialog = ref(false)

    const selectedCategory = computed(() => categories.value
        .find(category => category.id === selected.value))

    async function fetch()
    {
        const response = (await api.query(getCategoriesQuery))
            .getCategories

        categories.value.push(...response.categories)
    }

    async function remove(id: string)
    {
        (await api.mutation(removeCategoryMutation, { id }))

        categories.value = categories.value.filter(m => m.id !== id)
    }

    async function edit(id: string)
    {
        selected.value = id
        showEditDialog.value = true
    }

    onMounted(async () => await fetch())
</script>

<style lang='scss' scoped>    
    #actions
    {
        display: flex;
        grid-column-gap: 8px;
    }
</style>