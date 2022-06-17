# Versioning

Every project requires a unified set of rules to abide by - version control is no different.

## Commits

Messages should adhere to the following format:

`<label>: <description>`

E.g. 

`ref: removed unused strings`

Labels could be one of the following:
- `dev`  
change extends the project
- `ref`  
change cleans or optimizes the code
- `fix`  
change fixes an ongoing issue
- `build`  
change prepares project for the release
- `etc`
uncategorized change, e.g: updating readmes

## Branches

Branches should apply the following format:

`<type>/<issue/description>`

E.g.

`exp/new-load-balancer`

- `exp`
branch contains experimental code
- `ref`
branch cleans or optimizes the code
- `fix`
branch fixes an ongoing issue
- `backup`
branch contains backup of code I might reuse at some point in time
- `etc`
branch contains uncategorized changes, e.g: moving files to different repositories

## Tags

Tags should be applied to commits with `build` label and adhere to the following naming pattern:

`v<major>.<minor>.<patch>`

- `major` describes stable release number
- `minor` describes stable change number
- `patch` describes applied fixes