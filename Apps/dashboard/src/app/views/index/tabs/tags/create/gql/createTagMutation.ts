export const createTagMutation = `mutation ($request: CreateTagRequestInput!) {
	content_createTag(request: $request) {
		id
	}
}`