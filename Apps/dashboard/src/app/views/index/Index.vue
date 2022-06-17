<template>
    <div id='index'>
        <TabView id='tabs' lazy>
            <TabPanel header='Editor (x)'>
                <Editor/>
            </TabPanel>
            <TabPanel header='Articles'/>
            <TabPanel header='Posts'/>
            <TabPanel header='Tags'>
                <Tags/>
            </TabPanel>
            <TabPanel header='Categories'>
                <Categories/>
            </TabPanel>
            <TabPanel header='Media'/>
            <TabPanel header='Messages (x)'>
                <Messages/>
            </TabPanel>
            <TabPanel header='Profile (x)'>
                <Profile/>
            </TabPanel>
            <TabPanel header='Users (x)'>
                <Users/>
            </TabPanel>
        </TabView>
    </div>
</template>

<script lang='ts' setup>
    import Messages from './tabs/messages/Messages.vue'
    import Users from './tabs/users/Users.vue'
    import Categories from './tabs/categories/Categories.vue'
    import Tags from './tabs/tags/Tags.vue'
    import Profile from './tabs/profile/Profile.vue'
    import Editor from './tabs/editor/Editor.vue'
</script>

<style lang='scss' scoped>
    #index
    {
        display: flex;
        flex-grow: 1;
    }

    #tabs
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
    }

    :deep(.p-tabview-panels)
    {
        display: flex;
        flex-grow: 1;
    }

    :deep(.p-tabview-panel)
    {
        display: flex;
        flex-grow: 1;
    }
</style>