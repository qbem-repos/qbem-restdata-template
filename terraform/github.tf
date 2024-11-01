terraform {
  required_providers {
    github = {
      source = "integrations/github"
      version = "6.3.1"
    }
  }
}

variable "github_token" {
  type = string
}

variable "project_name" {
  type = string
}

provider "github" {
  token = var.github_token # Token precisa de permissão: https://github.com/settings/tokens
  owner = "qbem-repos"
}

resource "github_repository" "this" {
    name = var.project_name
    description = "TODO: "    
    visibility = "private"
    delete_branch_on_merge = true
    auto_init = true
    gitignore_template = "VisualStudio"
    archive_on_destroy = true
    vulnerability_alerts = true
    has_wiki = true
    archived = false    
    web_commit_signoff_required = true    
    pages {
        source {
          branch = "main"
          path   = "/docs"
      }
  }
}

resource "github_branch" "development" {
  repository = github_repository.this.name
  branch     = "main"
}

resource "github_branch_default" "default" {
  repository = github_repository.this.name
  branch     = github_branch.development.branch
  rename     = true
}


# resource "github_team" "admin" {
#   name = "Tech Lead"  
# }

# resource "github_team_repository" "admin" {
#   team_id    = github_team.admin.id
#   repository = github_repository.this.name
#   permission = "admin"
# }

# resource "github_team" "developers" {
#   name = "Developers"  
# }

# resource "github_team_repository" "this" {
#   team_id    = github_team.developers.id
#   repository = github_repository.this.name
#   permission = "push"
# }

# resource "github_branch_protection" "main" {
#   repository_id = github_repository.this.id
#   pattern                         = "main"
#   enforce_admins                  = false
#   require_signed_commits          = true
#   required_linear_history         = false
#   allows_deletions                = false
#   allows_force_pushes             = false
#   require_conversation_resolution = true

#   required_status_checks {
#     strict = true
#   }
  
#   required_pull_request_reviews {
#     restrict_dismissals             = true
#     require_code_owner_reviews      = true
#     require_last_push_approval      = true
#     required_approving_review_count = 1
#     pull_request_bypassers          = [github_team_repository.admin]
#   }

#   restrict_pushes {
#     blocks_creations = true
#     push_allowances  = [
#       github_repository.this.id,
#       github_team_repository.admin
#     ]
#   }
  
#   force_push_bypassers = [
#        github_repository.this.id,
#       github_team_repository.admin
#   ]
# }

 