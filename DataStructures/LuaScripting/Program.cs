﻿using StackExchange.Redis;

var muxer = ConnectionMultiplexer.Connect("localhost");
var db = muxer.GetDatabase();

var scriptText = @"
        local id = redis.call('incr', @id_key)
        local key = 'key:' .. id
        redis.call('set', key, @value)
        return key
    ";

var script = LuaScript.Prepare(scriptText);

var key1 = db.ScriptEvaluate(script, new { id_key = (RedisKey)"autoIncrement", value = "A String Value" });
var key2 = db.ScriptEvaluate(script, new { id_key = (RedisKey)"autoIncrement", value = "Another String Value" });

Console.WriteLine($"Key 1: {key1}");
Console.WriteLine($"Key 2: {key2}");

var nonPreparedScript = @"
        local id = redis.call('incr', KEYS[1])
        local key = 'key:' .. id
        redis.call('set', key, ARGV[1])
        return key
    ";

var key3 = db.ScriptEvaluate(nonPreparedScript, new RedisKey[] { "autoIncrement" }, new RedisValue[] { "Yet another string value" });
Console.WriteLine($"Key 3: {key3}");