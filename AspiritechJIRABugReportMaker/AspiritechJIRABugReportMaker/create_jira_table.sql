/*
This SQL file has no function, but I
included it in the repository to show what the
database table looks like.
*/
CREATE TABLE jira_reports (
	id INTEGER PRIMARY KEY,
	jira_id TEXT,
	time_reported DATETIME2,
	summary TEXT,
	reporter TEXT,
	test_case TEXT,
	test_step TEXT,
	homer_gabbo_version TEXT,
	device_versions TEXT,
	internet_connection_type TEXT,
	test_environment TEXT,
	steps_to_reproduce TEXT,
	expected_result TEXT,
	actual_result TEXT,
	times_repeatable_num INTEGER,
	times_repeatable_dem INTEGER,
	test_machine_names TEXT,
	workaround TEXT,
	other_notes_or_comments TEXT
	);