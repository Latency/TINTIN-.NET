









#define DO_ARRAY(array) struct session *array (struct session *ses, struct listnode *list, char *arg)
#define DO_CHAT(chat) void chat (char *left, char *right)
#define DO_CLASS(class) struct session *class (struct session *ses, char *left, char *right)
#define DO_COMMAND(command) struct session  *command (struct session *ses, char *arg)
#define DO_CONFIG(config) struct session *config (struct session *ses, char *arg, int index)
#define DO_MAP(map) void map (struct session *ses, char *arg, char *arg1, char *arg2)
#define DO_PATH(path) void path (struct session *ses, char *arg)
#define DO_LINE(line) struct session *line (struct session *ses, char *arg)
#define DO_CURSOR(cursor) void cursor (char *arg)
#define DO_HISTORY(history) void history (struct session *ses, char *arg)
#define DO_BUFFER(buffer) void buffer (struct session *ses, char *arg)




/************************ structures *********************/



struct tintin_data
{
	struct session        * ses;
	struct session        * update;
	struct session        * dispose_next;
	struct session        * dispose_prev;
	struct chat_data      * chat;
	struct termios          old_terminal;
	struct termios          new_terminal;
	char                  * mud_output_buf;
	int                     mud_output_max;
	int                     mud_output_len;
	unsigned char         * mccp_buf;
	int                     mccp_len;
	char                    input_buf[BUFFER_SIZE];
	char                    input_tmp[BUFFER_SIZE];
	char                    macro_buf[BUFFER_SIZE];
	char                    paste_buf[BUFFER_SIZE];
	int                     input_off;
	int                     input_len;
	int                     input_cur;
	int                     input_pos;
	int                     input_hid;
	char                  * term;
	long long               time;
	long long               timer[TIMER_CPU][5];
	long long               total_io_ticks;
	long long               total_io_exec;
	long long               total_io_delay;
	int                     str_hash_size;
	int                     history_size;
	int                     command_ref[26];
	int                     flags;
	int                     quiet;
	char                    tintin_char;
	char                    verbatim_char;
	char                    repeat_char;
	char                  * vars[100];
	char                  * cmds[100];
	int                     args[100];
};

struct chat_data
{
	struct chat_data      * next;
	struct chat_data      * prev;
	char                  * name;
	char                  * ip;
	char                  * version;
	char                  * download;
	char                  * reply;
	char                  * paste_buf;
	char                  * color;
	char                  * group;
	int                     port;
	int                     fd;
	time_t                  timeout;
	int                     flags;
	long long               paste_time;
	FILE                  * file_pt;
	char                  * file_name;
	long long               file_size;
	int                     file_block_cnt;
	int                     file_block_tot;
	int                     file_block_patch;
	long long               file_start_time;
};



/*
	Structures for tables.c
*/

struct array_type
{
	char                  * name;
	ARRAY                 * array;
	int                     lval;
	int                     rval;
};

struct chat_type
{
	char                  * name;
	CHAT                  * fun;
	int                     lval;
	int                     rval;
	char                  * desc;
};

struct class_type
{
	char                  * name;
	CLASS                 * group;
};

struct command_type
{
	char                  * name;
	COMMAND               * command;
	int                     type;
};

struct config_type
{
	char                  * name;
	char                  * msg_on;
	char                  * msg_off;
	CONFIG                * config;
};


struct list_type
{
	char                  * name;
	char                  * name_multi;
	int                     mode;
	int                     args;
	int                     flags;
};


struct map_type
{
	char                  * name;
	MAP                   * map;
	int                     check;
};

struct cursor_type
{
	char                  * name;
	char                  * desc;
	char                  * code;
	CURSOR                * fun;
};

struct timer_type
{
	char                  * name;
};

struct path_type
{
	char                  * name;
	PATH                  * fun; 	
};

struct line_type
{
	char                  * name;
	LINE                  * fun;
};

struct history_type
{
	char                  * name;
	HISTORY               * fun;
	char                  * desc;
};

struct buffer_type
{
	char                  * name;
	BUFFER                * fun;
	char                  * desc;
};

struct telopt_type
{
	char                  * name;
	int                     want;
	int                     flag;
};



struct str_hash_index_data
{
	struct str_hash_data    * f_node;
	struct str_hash_data    * l_node;
};

struct map_data
{
	struct room_data     ** room_list;
	struct room_data     ** grid;
	FILE                  * logfile;
	struct link_data      * undo_head;
	struct link_data      * undo_tail;
	struct grid_data      * grid_head;
	struct grid_data      * grid_tail;
	char                  * exit_color;
	char                  * here_color;
	char                  * path_color;
	char                  * room_color;
	int                     max_grid_x;
	int                     max_grid_y;
	int                     undo_size;
	int                     size;
	int                     flags;
	int                     in_room;
	int                     at_room;
	int                     last_room;
	short                   search_stamp;
	short                   display_stamp;
	short                   nofollow;
	char                    legend[17][100];
};


