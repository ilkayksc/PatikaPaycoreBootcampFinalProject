PGDMP         +    
            z            postgres    14.5    14.5 W    ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    14020    postgres    DATABASE     S   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'C';
    DROP DATABASE postgres;
                postgres    false            ?           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    3725                        2615    16483    hangfire    SCHEMA        CREATE SCHEMA hangfire;
    DROP SCHEMA hangfire;
                postgres    false                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false            ?           0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    2            ?            1259    16490    counter    TABLE     ?   CREATE TABLE hangfire.counter (
    id bigint NOT NULL,
    key text NOT NULL,
    value bigint NOT NULL,
    expireat timestamp without time zone
);
    DROP TABLE hangfire.counter;
       hangfire         heap    postgres    false    6            ?            1259    16489    counter_id_seq    SEQUENCE     y   CREATE SEQUENCE hangfire.counter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE hangfire.counter_id_seq;
       hangfire          postgres    false    6    218            ?           0    0    counter_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE hangfire.counter_id_seq OWNED BY hangfire.counter.id;
          hangfire          postgres    false    217            ?            1259    16498    hash    TABLE     ?   CREATE TABLE hangfire.hash (
    id bigint NOT NULL,
    key text NOT NULL,
    field text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.hash;
       hangfire         heap    postgres    false    6            ?            1259    16497    hash_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.hash_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.hash_id_seq;
       hangfire          postgres    false    220    6            ?           0    0    hash_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.hash_id_seq OWNED BY hangfire.hash.id;
          hangfire          postgres    false    219            ?            1259    16509    job    TABLE     '  CREATE TABLE hangfire.job (
    id bigint NOT NULL,
    stateid bigint,
    statename text,
    invocationdata text NOT NULL,
    arguments text NOT NULL,
    createdat timestamp without time zone NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.job;
       hangfire         heap    postgres    false    6            ?            1259    16508 
   job_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.job_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.job_id_seq;
       hangfire          postgres    false    6    222            ?           0    0 
   job_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.job_id_seq OWNED BY hangfire.job.id;
          hangfire          postgres    false    221            ?            1259    16569    jobparameter    TABLE     ?   CREATE TABLE hangfire.jobparameter (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    value text,
    updatecount integer DEFAULT 0 NOT NULL
);
 "   DROP TABLE hangfire.jobparameter;
       hangfire         heap    postgres    false    6            ?            1259    16568    jobparameter_id_seq    SEQUENCE     ~   CREATE SEQUENCE hangfire.jobparameter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE hangfire.jobparameter_id_seq;
       hangfire          postgres    false    233    6            ?           0    0    jobparameter_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE hangfire.jobparameter_id_seq OWNED BY hangfire.jobparameter.id;
          hangfire          postgres    false    232            ?            1259    16534    jobqueue    TABLE     ?   CREATE TABLE hangfire.jobqueue (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    queue text NOT NULL,
    fetchedat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.jobqueue;
       hangfire         heap    postgres    false    6            ?            1259    16533    jobqueue_id_seq    SEQUENCE     z   CREATE SEQUENCE hangfire.jobqueue_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE hangfire.jobqueue_id_seq;
       hangfire          postgres    false    6    226            ?           0    0    jobqueue_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE hangfire.jobqueue_id_seq OWNED BY hangfire.jobqueue.id;
          hangfire          postgres    false    225            ?            1259    16542    list    TABLE     ?   CREATE TABLE hangfire.list (
    id bigint NOT NULL,
    key text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.list;
       hangfire         heap    postgres    false    6            ?            1259    16541    list_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.list_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.list_id_seq;
       hangfire          postgres    false    6    228            ?           0    0    list_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.list_id_seq OWNED BY hangfire.list.id;
          hangfire          postgres    false    227            ?            1259    16583    lock    TABLE     ?   CREATE TABLE hangfire.lock (
    resource text NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL,
    acquired timestamp without time zone
);
    DROP TABLE hangfire.lock;
       hangfire         heap    postgres    false    6            ?            1259    16484    schema    TABLE     ?   CREATE TABLE hangfire.schema (
    version integer NOT NULL
);
    DROP TABLE hangfire.schema;
       hangfire         heap    postgres    false    6            ?            1259    16550    server    TABLE     ?   CREATE TABLE hangfire.server (
    id text NOT NULL,
    data text,
    lastheartbeat timestamp without time zone NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.server;
       hangfire         heap    postgres    false    6            ?            1259    16558    set    TABLE     ?   CREATE TABLE hangfire.set (
    id bigint NOT NULL,
    key text NOT NULL,
    score double precision NOT NULL,
    value text NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.set;
       hangfire         heap    postgres    false    6            ?            1259    16557 
   set_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.set_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.set_id_seq;
       hangfire          postgres    false    231    6            ?           0    0 
   set_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.set_id_seq OWNED BY hangfire.set.id;
          hangfire          postgres    false    230            ?            1259    16519    state    TABLE     ?   CREATE TABLE hangfire.state (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    reason text,
    createdat timestamp without time zone NOT NULL,
    data text,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.state;
       hangfire         heap    postgres    false    6            ?            1259    16518    state_id_seq    SEQUENCE     w   CREATE SEQUENCE hangfire.state_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE hangfire.state_id_seq;
       hangfire          postgres    false    224    6            ?           0    0    state_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE hangfire.state_id_seq OWNED BY hangfire.state.id;
          hangfire          postgres    false    223            ?            1259    16408    account    TABLE     >  CREATE TABLE public.account (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    surname character varying(50) NOT NULL,
    password character varying NOT NULL,
    dateofbirth date,
    phonenumber character varying(20) NOT NULL,
    email character varying(100) NOT NULL,
    lastactivity date
);
    DROP TABLE public.account;
       public         heap    postgres    false            ?            1259    16437    account_id_seq    SEQUENCE     ?   ALTER TABLE public.account ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    211            ?            1259    16783    brand    TABLE     ?   CREATE TABLE public.brand (
    id bigint NOT NULL,
    brandshortname character varying(50) NOT NULL,
    brandname character varying(150) NOT NULL
);
    DROP TABLE public.brand;
       public         heap    postgres    false            ?            1259    16788    buy    TABLE     ?   CREATE TABLE public.buy (
    id bigint NOT NULL,
    price double precision NOT NULL,
    productowner bigint NOT NULL,
    customer bigint NOT NULL,
    productid bigint NOT NULL
);
    DROP TABLE public.buy;
       public         heap    postgres    false            ?            1259    16416    category    TABLE     ?   CREATE TABLE public.category (
    categoryname character varying(50) NOT NULL,
    categorydescription character varying(350),
    id bigint NOT NULL
);
    DROP TABLE public.category;
       public         heap    postgres    false            ?            1259    16778    color    TABLE     ?   CREATE TABLE public.color (
    id bigint NOT NULL,
    colorname character varying(50) NOT NULL,
    colorcode character varying(150) NOT NULL
);
    DROP TABLE public.color;
       public         heap    postgres    false            ?            1259    16478    offers    TABLE     ?   CREATE TABLE public.offers (
    id bigint NOT NULL,
    productid bigint NOT NULL,
    price double precision NOT NULL,
    customer bigint NOT NULL,
    isaccept boolean NOT NULL
);
    DROP TABLE public.offers;
       public         heap    postgres    false            ?            1259    16438    product    TABLE     m  CREATE TABLE public.product (
    id bigint NOT NULL,
    productname character varying(100) NOT NULL,
    productdescription character varying(500) NOT NULL,
    categoryid bigint NOT NULL,
    color integer NOT NULL,
    brand integer NOT NULL,
    isofferable boolean NOT NULL,
    price double precision NOT NULL,
    productowner bigint,
    issold boolean
);
    DROP TABLE public.product;
       public         heap    postgres    false            ?           2604    16616 
   counter id    DEFAULT     l   ALTER TABLE ONLY hangfire.counter ALTER COLUMN id SET DEFAULT nextval('hangfire.counter_id_seq'::regclass);
 ;   ALTER TABLE hangfire.counter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    217    218    218            ?           2604    16625    hash id    DEFAULT     f   ALTER TABLE ONLY hangfire.hash ALTER COLUMN id SET DEFAULT nextval('hangfire.hash_id_seq'::regclass);
 8   ALTER TABLE hangfire.hash ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    219    220    220            ?           2604    16635    job id    DEFAULT     d   ALTER TABLE ONLY hangfire.job ALTER COLUMN id SET DEFAULT nextval('hangfire.job_id_seq'::regclass);
 7   ALTER TABLE hangfire.job ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    222    221    222            ?           2604    16685    jobparameter id    DEFAULT     v   ALTER TABLE ONLY hangfire.jobparameter ALTER COLUMN id SET DEFAULT nextval('hangfire.jobparameter_id_seq'::regclass);
 @   ALTER TABLE hangfire.jobparameter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    232    233    233            ?           2604    16708    jobqueue id    DEFAULT     n   ALTER TABLE ONLY hangfire.jobqueue ALTER COLUMN id SET DEFAULT nextval('hangfire.jobqueue_id_seq'::regclass);
 <   ALTER TABLE hangfire.jobqueue ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    226    225    226            ?           2604    16728    list id    DEFAULT     f   ALTER TABLE ONLY hangfire.list ALTER COLUMN id SET DEFAULT nextval('hangfire.list_id_seq'::regclass);
 8   ALTER TABLE hangfire.list ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    228    227    228            ?           2604    16737    set id    DEFAULT     d   ALTER TABLE ONLY hangfire.set ALTER COLUMN id SET DEFAULT nextval('hangfire.set_id_seq'::regclass);
 7   ALTER TABLE hangfire.set ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    231    230    231            ?           2604    16662    state id    DEFAULT     h   ALTER TABLE ONLY hangfire.state ALTER COLUMN id SET DEFAULT nextval('hangfire.state_id_seq'::regclass);
 9   ALTER TABLE hangfire.state ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    224    223    224            ?           2606    16618    counter counter_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY hangfire.counter
    ADD CONSTRAINT counter_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY hangfire.counter DROP CONSTRAINT counter_pkey;
       hangfire            postgres    false    218            ?           2606    16753    hash hash_key_field_key 
   CONSTRAINT     Z   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_key_field_key UNIQUE (key, field);
 C   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_key_field_key;
       hangfire            postgres    false    220    220            ?           2606    16627    hash hash_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_pkey;
       hangfire            postgres    false    220            ?           2606    16637    job job_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.job
    ADD CONSTRAINT job_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.job DROP CONSTRAINT job_pkey;
       hangfire            postgres    false    222            ?           2606    16687    jobparameter jobparameter_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_pkey;
       hangfire            postgres    false    233            ?           2606    16710    jobqueue jobqueue_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY hangfire.jobqueue
    ADD CONSTRAINT jobqueue_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY hangfire.jobqueue DROP CONSTRAINT jobqueue_pkey;
       hangfire            postgres    false    226            ?           2606    16730    list list_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.list
    ADD CONSTRAINT list_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.list DROP CONSTRAINT list_pkey;
       hangfire            postgres    false    228            ?           2606    16609    lock lock_resource_key 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.lock
    ADD CONSTRAINT lock_resource_key UNIQUE (resource);
 B   ALTER TABLE ONLY hangfire.lock DROP CONSTRAINT lock_resource_key;
       hangfire            postgres    false    234            ?           2606    16488    schema schema_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.schema
    ADD CONSTRAINT schema_pkey PRIMARY KEY (version);
 >   ALTER TABLE ONLY hangfire.schema DROP CONSTRAINT schema_pkey;
       hangfire            postgres    false    216            ?           2606    16756    server server_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY hangfire.server
    ADD CONSTRAINT server_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY hangfire.server DROP CONSTRAINT server_pkey;
       hangfire            postgres    false    229            ?           2606    16758    set set_key_value_key 
   CONSTRAINT     X   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_key_value_key UNIQUE (key, value);
 A   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_key_value_key;
       hangfire            postgres    false    231    231            ?           2606    16739    set set_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_pkey;
       hangfire            postgres    false    231            ?           2606    16664    state state_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_pkey;
       hangfire            postgres    false    224            ?           2606    16412    account account_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.account
    ADD CONSTRAINT account_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.account DROP CONSTRAINT account_pkey;
       public            postgres    false    211            ?           2606    16787    brand brand_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.brand
    ADD CONSTRAINT brand_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.brand DROP CONSTRAINT brand_pkey;
       public            postgres    false    236            ?           2606    16792    buy buy_pkey 
   CONSTRAINT     J   ALTER TABLE ONLY public.buy
    ADD CONSTRAINT buy_pkey PRIMARY KEY (id);
 6   ALTER TABLE ONLY public.buy DROP CONSTRAINT buy_pkey;
       public            postgres    false    237            ?           2606    16436    category category_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.category DROP CONSTRAINT category_pkey;
       public            postgres    false    212            ?           2606    16782    color color_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.color
    ADD CONSTRAINT color_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.color DROP CONSTRAINT color_pkey;
       public            postgres    false    235            ?           2606    16482    offers offers_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.offers
    ADD CONSTRAINT offers_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.offers DROP CONSTRAINT offers_pkey;
       public            postgres    false    215            ?           2606    16444    product product_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.product DROP CONSTRAINT product_pkey;
       public            postgres    false    214            ?           1259    16600    ix_hangfire_counter_expireat    INDEX     V   CREATE INDEX ix_hangfire_counter_expireat ON hangfire.counter USING btree (expireat);
 2   DROP INDEX hangfire.ix_hangfire_counter_expireat;
       hangfire            postgres    false    218            ?           1259    16747    ix_hangfire_counter_key    INDEX     L   CREATE INDEX ix_hangfire_counter_key ON hangfire.counter USING btree (key);
 -   DROP INDEX hangfire.ix_hangfire_counter_key;
       hangfire            postgres    false    218            ?           1259    16765    ix_hangfire_hash_expireat    INDEX     P   CREATE INDEX ix_hangfire_hash_expireat ON hangfire.hash USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_hash_expireat;
       hangfire            postgres    false    220            ?           1259    16762    ix_hangfire_job_expireat    INDEX     N   CREATE INDEX ix_hangfire_job_expireat ON hangfire.job USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_job_expireat;
       hangfire            postgres    false    222            ?           1259    16754    ix_hangfire_job_statename    INDEX     P   CREATE INDEX ix_hangfire_job_statename ON hangfire.job USING btree (statename);
 /   DROP INDEX hangfire.ix_hangfire_job_statename;
       hangfire            postgres    false    222            ?           1259    16759 %   ix_hangfire_jobparameter_jobidandname    INDEX     g   CREATE INDEX ix_hangfire_jobparameter_jobidandname ON hangfire.jobparameter USING btree (jobid, name);
 ;   DROP INDEX hangfire.ix_hangfire_jobparameter_jobidandname;
       hangfire            postgres    false    233    233            ?           1259    16719 "   ix_hangfire_jobqueue_jobidandqueue    INDEX     a   CREATE INDEX ix_hangfire_jobqueue_jobidandqueue ON hangfire.jobqueue USING btree (jobid, queue);
 8   DROP INDEX hangfire.ix_hangfire_jobqueue_jobidandqueue;
       hangfire            postgres    false    226    226            ?           1259    16612 &   ix_hangfire_jobqueue_queueandfetchedat    INDEX     i   CREATE INDEX ix_hangfire_jobqueue_queueandfetchedat ON hangfire.jobqueue USING btree (queue, fetchedat);
 <   DROP INDEX hangfire.ix_hangfire_jobqueue_queueandfetchedat;
       hangfire            postgres    false    226    226            ?           1259    16763    ix_hangfire_list_expireat    INDEX     P   CREATE INDEX ix_hangfire_list_expireat ON hangfire.list USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_list_expireat;
       hangfire            postgres    false    228            ?           1259    16764    ix_hangfire_set_expireat    INDEX     N   CREATE INDEX ix_hangfire_set_expireat ON hangfire.set USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_set_expireat;
       hangfire            postgres    false    231            ?           1259    16773    ix_hangfire_set_key_score    INDEX     Q   CREATE INDEX ix_hangfire_set_key_score ON hangfire.set USING btree (key, score);
 /   DROP INDEX hangfire.ix_hangfire_set_key_score;
       hangfire            postgres    false    231    231            ?           1259    16672    ix_hangfire_state_jobid    INDEX     L   CREATE INDEX ix_hangfire_state_jobid ON hangfire.state USING btree (jobid);
 -   DROP INDEX hangfire.ix_hangfire_state_jobid;
       hangfire            postgres    false    224            ?           1259    16760    jobqueue_queue_fetchat_jobid    INDEX     f   CREATE INDEX jobqueue_queue_fetchat_jobid ON hangfire.jobqueue USING btree (queue, fetchedat, jobid);
 2   DROP INDEX hangfire.jobqueue_queue_fetchat_jobid;
       hangfire            postgres    false    226    226    226            ?           2606    16696 $   jobparameter jobparameter_jobid_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_jobid_fkey;
       hangfire          postgres    false    233    3547    222            ?           2606    16673    state state_jobid_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 B   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_jobid_fkey;
       hangfire          postgres    false    222    224    3547            ?           2606    16445    product fk_3ab29c28    FK CONSTRAINT     x   ALTER TABLE ONLY public.product
    ADD CONSTRAINT fk_3ab29c28 FOREIGN KEY (categoryid) REFERENCES public.category(id);
 =   ALTER TABLE ONLY public.product DROP CONSTRAINT fk_3ab29c28;
       public          postgres    false    212    214    3528           