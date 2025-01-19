using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebHooks.GitHub.Contracts;

public class GithubWebhookRequest
{
	[JsonPropertyName("ref")]
	public string Ref { get; set; }

	[JsonPropertyName("ref_type")]
	public string RefType { get; set; }

	[JsonPropertyName("master_branch")]
	public string MasterBranch { get; set; }

	[JsonPropertyName("description")]
	public object Description { get; set; }

	[JsonPropertyName("pusher_type")]
	public string PusherType { get; set; }

	[JsonPropertyName("repository")]
	public Repository Repository { get; set; }
}

public class Repository
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("node_id")]
	public string NodeId { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("full_name")]
	public string FullName { get; set; }

	[JsonPropertyName("private")]
	public bool Private { get; set; }

	[JsonPropertyName("html_url")]
	public string HtmlUrl { get; set; }

	[JsonPropertyName("description")]
	public object Description { get; set; }

	[JsonPropertyName("fork")]
	public bool Fork { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime UpdatedAt { get; set; }

	[JsonPropertyName("pushed_at")]
	public DateTime PushedAt { get; set; }

	[JsonPropertyName("git_url")]
	public string GitUrl { get; set; }

	[JsonPropertyName("ssh_url")]
	public string SshUrl { get; set; }

	[JsonPropertyName("clone_url")]
	public string CloneUrl { get; set; }

	[JsonPropertyName("svn_url")]
	public string SvnUrl { get; set; }

	[JsonPropertyName("topics")]
	public object[] Topics { get; set; }

	[JsonPropertyName("visibility")]
	public string Visibility { get; set; }

	[JsonPropertyName("default_branch")]
	public string DefaultBranch { get; set; }
}
