<template>
    <div id='playground-index'>
        <div id='buttons'>
            <template v-for='t in ButtonType' :key='t'>
                <Button :type='t'
                    :text='t'
                />
                <Button :type='t'
                    text='disabled'
                    disabled
                />
            </template>
        </div>
        <div id='icon-buttons'>
            <template v-for='t in ButtonType' :key='t'>
                <IconButton v-for='icon in iconButtons' 
                    :key='icon'
                    :icon='icon'
                    :type='t'
                />
            </template>
        </div>
        <div id='badges'>
            <CategoryBadge v-for='category in dummyCategories'
                :key='category.id'    
                :category='category'
            />
            <TagBadge v-for='tag in dummyTags'
                :key='tag.id'    
                :tag='tag'
            />
            <UserBadge v-for='user in dummyUsers'
                :key='user.id'
                :user='user'
            />
        </div>
        <div id='notes'>
            <Note v-for='t in NoteType'
                :key='t'
                :type='t' 
                :text='t'
            />
        </div>
        <div id='noteblocks'>
            <NoteBlock v-for='(t, _, i) in NoteType'
                :key='t'
                :type='t' 
                :text='"First line\nsecond line"'
                :decay='(i + 1) * 5000'
            />
        </div>
        <div id='inputs'>
            <InputField/>
            <InputField placeholder='Placeholder'/>
            <InputField label='Username'/>
            <InputField placeholder='Password' label='User'/>
        </div>
        <div id='dialogs'>
            <Dialog :show='showDialog'>
                <p>
                    This is a sample dialog
                </p>
                <Button text='Close' @click='showDialog = false'/>
            </Dialog>
            <Button :type='ButtonType.Info' 
                text='Show Dialog'
                @click='showDialog = true'
            />
        </div>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, ref } from 'vue'
    import { ButtonType } from '@/app/components/controls/buttons/ButtonType'
    import { NoteType } from '@/app/components/notes/NoteType'
    import { ICategory, ITag, IAuthor } from '@/core/domain/api'

    defineProps(
    {
        text: 
        {
            type: String,
            default: 'Label'
        },
        type:
        {
            type: String as PropType<ButtonType>
        },
    })

    const showDialog = ref(false)

    const iconButtons: Array<string> =
    [
        'notifications',
        'mic',
        'key'
    ]

    const dummyCategories: Array<ICategory> = 
    [
        {
            id: '1==',
            name: 'Soccer',
            description: 'Category description',
        },
        {
            id: '2==',
            name: 'Food',
            description: 'Category description',
        },
        {
            id: '3==',
            name: 'Cars',
            description: 'Category description',
        }
    ]

    const dummyTags: Array<ITag> = 
    [
        {
            id: '1==',
            name: 'Vue',
            description: 'Tag description',
        },
        {
            id: '2==',
            name: 'Decompilation',
            description: 'Tag description',
        },
        {
            id: '3==',
            name: 'Flexbox',
            description: 'Tag description',
        }
    ]

    const dummyUsers: Array<IAuthor> =
    [
        {
            id: '1==',
            nickname: 'User 1',
            avatarUrl: '/images/self.png'
        },
        {
            id: '2==',
            nickname: 'User 2',
            avatarUrl: '/images/self.png'
        }
    ]
</script>

<style lang='scss' scoped>
    #playground-index
    {
        display: grid;
        grid-row-gap: 16px;
        align-items: flex-start;
        align-self: flex-start;
        padding: 16px;
        max-height: 100vh;
        overflow-x: auto;
    }

    #notes, #noteblocks, #buttons, #icon-buttons, #inputs, #dialogs
    {
        display: flex;
        flex-wrap: wrap;
        grid-gap: 16px;
    }

    #buttons
    {
        display: grid;
        justify-self: flex-start;
        grid-template-columns: 1fr 1fr;
    }

    #noteblocks
    {
        flex-direction: column;
        grid-row-gap: 8px;
    }

    #badges
    {
        display: flex;
        align-items: flex-start;
        justify-items: flex-start;
        grid-column-gap: 16px;
    }
</style>