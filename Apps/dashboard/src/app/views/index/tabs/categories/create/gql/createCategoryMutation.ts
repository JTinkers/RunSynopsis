export const createCategoryMutation = `mutation ($request: CreateCategoryRequestInput!) {
	content_createCategory(request: $request) {
		id
	}
}`