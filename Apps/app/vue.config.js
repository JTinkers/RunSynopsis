const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig(
{
    transpileDependencies: true,
    css:
    {
        loaderOptions:
        {
            scss:
            {
                additionalData: 
                `
                    @import '@/app/assets/scss/_variables.scss';
                    @import '@/app/assets/scss/themes/light/_variables.scss';
                `
            }
        }
    }
})
