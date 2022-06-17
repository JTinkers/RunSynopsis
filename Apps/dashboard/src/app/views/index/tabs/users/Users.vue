<template>
    <div id='users'>
        <Panel header='Manage Permissions' 
            toggleable 
            collapsed
        >
            <ManagePermissions :user='selectedUser'/>
        </Panel>        
        <Panel header='Index' 
            toggleable 
            collapsed
        >
            <Index @selected-user='handleSelectedUser'/>
        </Panel>
    </div>
</template>

<script lang='ts' setup>
    import Index from './index/Index.vue'
    import ManagePermissions from './manage-permissions/ManagePermissions.vue'
    import { ref } from 'vue'
    import { IUser } from '@/core/domain/api'

    const selectedUser = ref<IUser | null>(null)

    function handleSelectedUser(user: IUser | null)
    {
        selectedUser.value = user
    }
</script>

<style lang='scss' scoped>
    #users
    {
        flex-grow: 1;
    }
</style>