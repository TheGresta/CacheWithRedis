# CacheWithRedis

## :arrow_double_down: ICachableRequest :arrow_double_down:

* BypassCache => If this value is true, program will ignore this cache and will run the command.
* CacheKey => The string value to map the result. With this key, we can access the result whenever we want.
* SlidingExpiration => Time cost for the cache. After the given time pass, Redis will delete this result from memory.

---

## :arrow_double_down: ICacheRemoverRequest :arrow_double_down:

* BypassCache => If this value is true, program will ignore this cache and will run the command.
* CacheKey => The string value to access the keys. With this key, remove the caches we want from the Redis memory. Whichever key has this value in the name, will be deleted from the memory.

---

## :arrow_double_down: Examples :arrow_double_down:

### :one: GetByIdCityQuery

``` ruby
    public bool BypassCache => false;

    public string CacheKey => $"{this.GetType().Name}&id={this.Id}";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(10);
```

### :two: GetListCityQuery

``` ruby
    public bool BypassCache => false;

    public string CacheKey => $"{this.GetType().Name}&pagesize={this.PageRequest.Page}&page{this.PageRequest.PageSize}";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(20);
```

### :three: GetListCityQuery

``` ruby
    public bool BypassCache => true;

    public string CacheKey => "City";
```

---

## :arrow_double_down: Screenshots :arrow_double_down:

<p align="center">
  <img src="https://user-images.githubusercontent.com/74189776/197393948-11791a7f-9edd-432d-b2e2-c26f0a465b63.png"/>
</p>

<p align="center">
  <img src="https://user-images.githubusercontent.com/74189776/197394145-a6ad808b-9808-4616-805e-19b44aea2d20.png"/>
</p>
